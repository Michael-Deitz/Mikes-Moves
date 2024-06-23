import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { deleteTrailer, getAllTrailersWithUserDetailsById } from "../../managers/trailerManager";
import PageContainer from "../PageContainer";
import { Badge, Button, ButtonToolbar, Card, CardBody, CardTitle, ListGroup, ListGroupItem } from "reactstrap";
import ConfirmDeleteModal from "../modals/ConfirmDeleteModal";
import DefaultTrailer from "../../resources/DefaultTrailer.jpg";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { ReserveTrailer, getReservedTrailer } from "../../managers/reserveManager";
import { toast, ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import ReservedTrailersModal from "../modals/ReservedTrailersModal"; // Import the modal

export default function TrailerDetails({ loggedInUser }) {
    const [trailers, setTrailers] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [trailerIdToDelete, setTrailerIdToDelete] = useState(null);
    const [reservationDate, setReservationDate] = useState(new Date());
    const [reservedDates, setReservedDates] = useState([]);
    const [reservedTrailersModalOpen, setReservedTrailersModalOpen] = useState(false); // State for reserved trailers modal
    const [reservedTrailers, setReservedTrailers] = useState([]); // State for reserved trailers list

    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        getAllTrailersWithUserDetailsById(id).then(setTrailers);
        getReservedTrailer(id).then(reservations => {
            const dates = reservations.map(reservation => new Date(reservation.dateReserved));
            setReservedDates(dates);
        });
    }, [id]);

    const currentUser = (userId) => {
        return loggedInUser && userId === loggedInUser.id;
    }

    const toggleModal = () => {
        setIsModalOpen(!isModalOpen);
    }

    const handleDeleteModal = (id) => {
        setTrailerIdToDelete(id);
        toggleModal();
    }

    const handleDelete = () => {
        deleteTrailer(trailerIdToDelete).then(() => {
            setTrailers(trailers.filter(t => t.id !== trailerIdToDelete));
        }).then(() => navigate("/trailers"));
    }

    const handleReserve = (id) => {
        if (isDateDisabled(reservationDate)) {
            toast.error("This date is already reserved. Please choose another date.");
            return;
        }

        const reservation = {
            UserId: loggedInUser.id,
            TrailerId: id,
            DateReserved: reservationDate
        };

        ReserveTrailer(reservation)
        .then(() => {
            toast.success("Reservation successful!");
            getReservedTrailer(id).then(reservations => {
                const dates = reservations.map(reservation => new Date(reservation.dateReserved));
                setReservedDates(dates);
            });
        })
        .catch(() => {
            toast.error("Failed to make reservation.");
        });
    };

    const isDateDisabled = (date) => {
        return reservedDates.some(reservedDate =>
            date.getFullYear() === reservedDate.getFullYear() &&
            date.getMonth() === reservedDate.getMonth() &&
            date.getDate() === reservedDate.getDate()
        );
    };

    const toggleReservedTrailersModal = () => {
        if (!reservedTrailersModalOpen) {
            getReservedTrailer(id).then(reservations => {
                const userReservations = reservations.filter(reservation => reservation.userId === loggedInUser.id);
                setReservedTrailers(userReservations);
            });
        }
        setReservedTrailersModalOpen(!reservedTrailersModalOpen);
    };
    

    return (
        <PageContainer>
            <ToastContainer/>
            <div>
                <h1>Owners info</h1>
            </div>
            {trailers.map((t) => (
                <Card key={t.id} style={{ width: '40rem', marginBottom: '20px' }}>
                    <img src={t.imageUrl || DefaultTrailer} alt={t.description} style={{ height: '20rem' }} className="card-img-top" />
                    <CardBody>
                        <CardTitle>{t.description}</CardTitle>
                        <div className="row">
                            <div className="col">
                                <ListGroup>
                                    <ListGroupItem>
                                        <Badge>Height :</Badge> {t.height}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Width :</Badge> {t.width}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Length :</Badge> {t.length}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Capacity :</Badge> {t.capacity}lbs
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Type :</Badge> {t.type}
                                    </ListGroupItem>
                                    {currentUser(t.userProfileId) && (
                                        <ButtonToolbar className="gap-2 m-3">
                                            <Button style={{ width: "5rem" }} color="primary" onClick={() => navigate('edit')}>Edit</Button>
                                            <Button style={{ width: "5rem" }} color="danger" onClick={() => handleDeleteModal(t.id)}>Delete</Button>
                                        </ButtonToolbar>
                                    )}
                                </ListGroup>
                                <ConfirmDeleteModal
                                    isOpen={isModalOpen}
                                    toggle={toggleModal}
                                    confirmDelete={handleDelete}
                                    typeName={"trailer"}
                                />
                            </div>
                            <div className="col">
                                <ListGroup>
                                    <ListGroupItem>
                                        <Badge>Base Cost:</Badge> ${t.basePrice}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Price Per Mile:</Badge> ${t.pricePerMile}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Owner Name:</Badge> {t.userProfiles.fullName}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Phone Number:</Badge> {t.userProfiles.phoneNumber}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Email:</Badge> {t.userProfiles.email}
                                    </ListGroupItem>
                                </ListGroup>
                            </div>
                        </div>
                                    {!currentUser(t.userProfileId) && (
                                                    <div className="d-flex gap-2 align-items-center" style={{margin: "2rem"}}>
                                                        <DatePicker
                                                            selected={reservationDate}
                                                            onChange={date => setReservationDate(date)}
                                                            minDate={new Date()} // Minimum selectable date is today
                                                            filterDate={date => !isDateDisabled(date)} // Disable reserved dates
                                                            isClearable
                                                        />
                                                        <ButtonToolbar className="d-flex gap-2">
                                                            <Button style={{ width: "5rem" }} color="success" onClick={() => handleReserve(t.id)}>Reserve</Button>
                                                            <Button color="primary" onClick={toggleReservedTrailersModal}>View My Reservations</Button>
                                                        </ButtonToolbar>
                                                    </div>
                                                )}
                    </CardBody>
                </Card>
            ))}
            <ReservedTrailersModal
                isOpen={reservedTrailersModalOpen}
                toggle={toggleReservedTrailersModal}
                reservedTrailers={reservedTrailers}
            />
        </PageContainer>
    );
}





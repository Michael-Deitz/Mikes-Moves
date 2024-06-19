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

export default function TrailerDetails({ loggedInUser }) {
    const [trailers, setTrailers] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [trailerIdToDelete, setTrailerIdToDelete] = useState(null);
    const [reservationDate, setReservationDate] = useState(new Date());
    const [reservedDates, setReservedDates] = useState([]);

    const navigate = useNavigate();
    const { id } = useParams();

    useEffect(() => {
        getAllTrailersWithUserDetailsById(id).then(setTrailers);
        getReservedTrailer(id).then(reservations => {
            const dates = reservations.map(reservation => new Date(reservation.dateReserved));
            setReservedDates(dates);
        });
    }, [id, reservedDates]);

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
        const reservation = {
            UserId: loggedInUser.id,
            TrailerId: id,
            DateReserved: reservationDate
        };

        ReserveTrailer(reservation)
        .then(() => {
            toast.success("Reservation successful!");
            // Optionally, refresh the reserved dates list to reflect the new reservation
            getReservedTrailer(id).then(setReservedDates);
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

    return (
        <PageContainer>
            <ToastContainer/>
            <div>
                <h1>Owners info</h1>
            </div>
            {trailers.map((t) => (
                <Card key={t.id} style={{ width: '40rem', marginBottom: '20px' }}>
                    <img src={t.imageUrl} alt={t.description} style={{height: '20rem'}} className="card-img-top"/>
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
                                        <ButtonToolbar className="gap-2 m-3" >
                                            <Button style={{width: "5rem"}} color="primary" onClick={() => navigate('edit')}>edit</Button>
                                            <Button style={{width: "5rem"}} color="danger" onClick={() => handleDeleteModal(t.id)}>delete</Button>
                                        </ButtonToolbar>
                                    )}
                                    {!currentUser(t.userProfileId) && (
                                        <div>
                                            <DatePicker
                                                selected={reservationDate}
                                                onChange={date => setReservationDate(date)}
                                                minDate={new Date()} // Minimum selectable date is today
                                                filterDate={date => !isDateDisabled(date)} // Disable reserved dates
                                                 isClearable
                                            />
                                            <ButtonToolbar className="gap-2 m-3">
                                                <Button style={{width: "5rem"}} color="primary" onClick={() => handleReserve(t.id)}>Reserve</Button>
                                            </ButtonToolbar>
                                        </div>
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
                                        <Badge>Owner Name</Badge> {t.userProfiles.fullName}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Phone Number</Badge> {t.userProfiles.phoneNumber}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Email</Badge> {t.userProfiles.email}
                                    </ListGroupItem>
                                </ListGroup>
                            </div>
                        </div>
                    </CardBody>
                </Card>
            ))}
        </PageContainer>
    );
}



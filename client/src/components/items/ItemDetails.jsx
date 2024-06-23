import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { deleteItem, getAllItemsWithUserDetailsById } from "../../managers/itemManager";
import PageContainer from "../PageContainer";
import { Badge, Button, ButtonToolbar, Card, CardBody, CardTitle, ListGroup, ListGroupItem } from "reactstrap";
import ConfirmDeleteModal from "../modals/ConfirmDeleteModal";

export default function ItemDetails({ loggedInUser}) {
    const [items, setItems] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false)
    const [itemIdToDelete, setItemIdToDelete] = useState(null);

    const navigate = useNavigate();

    const {id} = useParams();

    useEffect(() => {
        getAllItemsWithUserDetailsById(id).then(setItems)
    }, [])

    const currentUser = (userId) => {
        return loggedInUser && userId == loggedInUser.id;
    }

    const toggleModal = () => {
        setIsModalOpen(!isModalOpen)
    }

    const handleDeleteModal = (id) => {
        setItemIdToDelete(id);
        toggleModal();
    }

    const handleDelete = () => {
        deleteItem(itemIdToDelete).then(() => {
            setItems(items.filter(i => i.id !== itemIdToDelete));
        }).then(() => {navigate("/items")})
    }

    return (
        <PageContainer>
            <div>
                <h1>Owners info</h1>
            </div>
            {items.map((i) => (
                <Card key={i.id} style={{ width: '40rem', marginBottom: '20px' }}>
                    <img src={i.imageUrl} alt={i.description} style={{height: '20rem'}} className="card-img-top"/>
                    <CardBody>
                        <CardTitle>{i.name}</CardTitle>
                        <div className="row">
                            <div className="col">
                                <ListGroup>
                                <ListGroupItem>
                                        <Badge>Height :</Badge> {i.height}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Width :</Badge> {i.width}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Length :</Badge> {i.length}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Weight :</Badge> {i.weight}lbs
                                    </ListGroupItem>
                                    {currentUser(i.userProfileId) && (
                                        <ButtonToolbar className="gap-2 m-3" >
                                        <Button className="" style={{width: "5rem"}} color="primary" onClick={() => navigate('edit')}>Edit</Button>
                                        <Button className="" style={{width: "5rem"}} color="danger" onClick={() => handleDeleteModal(i.id)}>Delete</Button>
                                        </ButtonToolbar>
                                    )} 
                                </ListGroup>
                                <ConfirmDeleteModal
                                    isOpen={isModalOpen}
                                    toggle={toggleModal}
                                    confirmDelete={handleDelete}
                                    typeName={"item"}
                                />
                            </div>
                            <div className="col">
                                <ListGroup>
                                    <ListGroupItem>
                                        <Badge>Owner Name</Badge> {i.userProfile.fullName}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Phone Number</Badge> {i.userProfile.phoneNumber}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Email</Badge> {i.userProfile.email}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Description</Badge> {i.description}
                                    </ListGroupItem>
                                </ListGroup>
                            </div>
                        </div>
                    </CardBody>
                </Card>
            ))}
        </PageContainer>
    )
}
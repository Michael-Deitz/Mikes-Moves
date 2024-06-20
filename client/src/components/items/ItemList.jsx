import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getAllItems } from "../../managers/itemManager";
import PageContainer from "../PageContainer";
import { Badge, Button, Card, CardBody, CardTitle, Input, ListGroup, ListGroupItem } from "reactstrap";
import FilterModal from "../modals/FilterModal";

export default function ItemList({ loggedInUser }) {
    const [items, setItems] = useState([]);
    const [filteredItems, setFilteredItems] = useState([])
    const [filterOption, setFilterOption] = useState("all");

    const navigate = useNavigate();

    useEffect(() => {
        getAllItems().then(setItems)
    }, [])

    useEffect(() => {
        if (filterOption === "all") {
            setFilteredItems(items);
        } else if (filterOption === "my") {
            setFilteredItems(items.filter(i => i.userProfileId === loggedInUser.id));
        }
    }, [filterOption, items, loggedInUser]);

    return (
        <PageContainer>
            <div>
                <h1>Items</h1>
            </div>
            <div  className="d-flex gap-3">
                <div>
                    <Input
                        type="select"
                        required
                        value={filterOption}
                        onChange={event => setFilterOption(event.target.value)}
                    >
                        <option value="all" key="all-items">
                            All Items
                        </option>
                        <option value="my" key="my-items">
                            My Items
                        </option>
                    </Input>
                </div>
                <div><Button color="success" onClick={() => navigate("/items/create")}>Add Items</Button></div>
            </div>
            {filteredItems.map((i) => (
                <Card key={i.id} className="shadow " style={{ width: '28rem', marginBottom: '20px', height: "auto" }}>
                    <img src={i.imageUrl} alt={i.description} className="card-img-top" style={{ height: "20rem"}}/>
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
                                </ListGroup>
                            </div>
                            <div className="col">
                                <ListGroup>
                                    <ListGroupItem>
                                    <Badge>Description :</Badge> {i.description}
                                    </ListGroupItem>
                                        <Button className="m-5" style={{width: "5rem"}} color="primary" onClick={() => navigate(`/items/${i.id}`)}>View</Button> 
                                </ListGroup>
                            </div>
                        </div>
                    </CardBody>
                </Card>
            ))}
        </PageContainer>
    )
}
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getAllTrailers } from "../../managers/trailerManager";
import PageContainer from "../PageContainer";
import { Badge, Button, Card, CardBody, CardTitle, Input, ListGroup, ListGroupItem } from "reactstrap";
import DefaultTrailer from "../../resources/DefaultTrailer.jpg";

export default function TrailerList({ loggedInUser }) {
    const [trailers, setTrailers] = useState([]);
    const [filteredTrailers, setFilteredTrailers] = useState([])
    const [filterOption, setFilterOption] = useState("all");

    const navigate = useNavigate();

    useEffect(() => {
        getAllTrailers().then(setTrailers)
    }, []);

    useEffect(() => {
        if (filterOption === 'all') {
            setFilteredTrailers(trailers);
        } else if (filterOption === 'my') {
            setFilteredTrailers(trailers.filter(t => t.userProfileId === loggedInUser.id));
        }
    }, [filterOption, trailers, loggedInUser]);

    return (
        <PageContainer>
            <div>
                <h1>Trailers</h1>
            </div>
            <div className="d-flex gap-3 ">
                <div>
                    <Input
                        type="select"
                        required
                        value={filterOption}
                        onChange={event => setFilterOption(event.target.value)}
                    >
                        <option value="all" key="all-trailers">
                            All Trailers
                        </option>
                        <option value="my" key="my-trailers">
                            My Trailers
                        </option>
                    </Input>
                </div>
                <div><Button color="success" onClick={() => navigate("/trailers/create")}>Add Trailer</Button></div>
            </div>
            {filteredTrailers.map((t) => (
                <Card key={t.id} className="shadow-sm" style={{ width: '28rem', marginBottom: '20px' }}>
                    <img src={t.imageUrl || DefaultTrailer} alt={t.description} className="card-img-top"/>
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
                                </ListGroup>
                            </div>
                            <div className="col">
                                <ListGroup>
                                    <ListGroupItem>
                                        <Badge>Base Cost:</Badge> ${t.basePrice}
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Price Per Mile:</Badge> ${t.pricePerMile}
                                    </ListGroupItem>
                                        <Button className="m-5" style={{width: "5rem"}} color="primary" onClick={() => navigate(`/trailers/${t.id}`)}>View</Button> 
                                </ListGroup>
                            </div>
                        </div>
                    </CardBody>
                </Card>
            ))}
        </PageContainer>
    )
}
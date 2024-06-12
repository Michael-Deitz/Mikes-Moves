import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getAllTrailers } from "../../managers/trailerManager";
import PageContainer from "../PageContainer";
import { Badge, Button, Card, CardBody, CardTitle, ListGroup, ListGroupItem } from "reactstrap";

export default function TrailerList() {
    const [trailers, setTrailers] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        getAllTrailers().then(setTrailers)
    }, []);

    return (
        <PageContainer>
            <div>
                <h1>Trailers</h1>
            </div>
            {trailers.map((t) => (
                <Card key={t.id} style={{ width: '28rem', marginBottom: '20px' }}>
                    <img src={t.imageUrl} alt={t.description} />
                    <CardBody>
                        <CardTitle>{t.description}</CardTitle>
                        <div className="row">
                            <div className="col">
                                <ListGroup>
                                    <ListGroupItem>
                                        <Badge>Height:</Badge> {t.height}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Width:</Badge> {t.width}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Length:</Badge> {t.length}ft
                                    </ListGroupItem>
                                    <ListGroupItem>
                                        <Badge>Capacity:</Badge> {t.capacity}lbs
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
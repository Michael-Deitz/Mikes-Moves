import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getAllTrailers } from "../../managers/trailerManager";
import PageContainer from "../PageContainer";
import { Badge, Card, CardBody, CardTitle, ListGroup, ListGroupItem } from "reactstrap";

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
            {trailers.map(t => {
                return (
                    <Card key={t.id} style={{width: '18rem'}}>
                        <img  src={t.imageUrl}/>
                        <CardBody>
                          <CardTitle>{t.description}</CardTitle>  
                        </CardBody>
                        <ListGroup flush >
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
                    </Card>
                )
            })}
        </PageContainer>
    )
}
import { useNavigate, useParams } from "react-router-dom";
import { createTrailer, getTrailersById, updateTrailer } from "../../managers/trailerManager";
import PageContainer from "../PageContainer";
import { Button, ButtonToolbar, Card, CardBody, Form, FormGroup, Input, Label } from "reactstrap";
import { useEffect, useState } from "react";
import DefaultTrailer from "../../resources/DefaultTrailer.jpg";

export default function CreateTrailer({ loggedInUser }) {
    const [type, setType] = useState("");
    const [description, setDescription] = useState("");
    const [height, setHeight] = useState(0);
    const [width, setWidth] = useState(0);
    const [length, setLength] = useState(0);
    const [capacity, setCapacity] = useState(0);
    const [basePrice, setBasePrice] = useState(0);
    const [pricePerMile, setPricePerMile] = useState(0);
    const [location, setLocation] = useState("");
    const [imageUrl, setImageUrl] = useState("");
    const [updateTrailerItem, setUpdateTrailerItem] = useState({});

    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        if (id) {
            getTrailersById(id).then((trailer) => {
                setUpdateTrailerItem(trailer);
                setType(trailer.type);
                setDescription(trailer.description);
                setLocation(trailer.location);
                setHeight(trailer.height);
                setWidth(trailer.width);
                setLength(trailer.length);
                setCapacity(trailer.capacity);
                setBasePrice(trailer.basePrice);
                setPricePerMile(trailer.pricePerMile);
                setImageUrl(trailer.imageUrl || DefaultTrailer);
            });
        }
    }, [id, DefaultTrailer]);

    const handleSubmit = (e) => {
        e.preventDefault();

        const trailer = {
            type: type,
            description: description,
            location: location,
            height: height,
            width: width,
            length: length,
            capacity: capacity,
            basePrice: basePrice,
            pricePerMile: pricePerMile,
            imageUrl: imageUrl || DefaultTrailer,
            userProfileId: loggedInUser.id
        };

        if (id) {
            updateTrailer(updateTrailerItem.id, trailer).then(() => navigate('/trailers'));
        } else {
            createTrailer(trailer).then(() => navigate("/trailers"));
        }
    }

    return (
        <PageContainer>
            {id ? (
                <h4 className="mt-2" style={{ display: 'flex', justifyContent: 'center' }}>Edit Your Trailer</h4>
            ) : (
                <h4 className="mt-2" style={{ display: 'flex', justifyContent: 'center' }}>Create A Trailer</h4>
            )}
            <Card className="w-75 shadow" outline color="light" style={{ maxWidth: "1200px" }}>
                <CardBody>
                    <Form className="w-50 m-auto"
                        style={{ maxWidth: "20rem" }}
                        onSubmit={handleSubmit}
                    >
                        <FormGroup>
                            <Label>Trailer Image</Label>
                            <Input
                                type="text"
                                value={imageUrl}
                                placeholder="Enter an image Url"
                                onChange={(e) => setImageUrl(e.target.value)}
                            />
                            {imageUrl && ( // Render preview if imageUrl is provided
                                <img
                                src={imageUrl}
                                alt="User"
                                style={{ width: "100px", marginTop: "10px" }}
                                />
                            )}
                            {!imageUrl && ( // Render default image if imageUrl is empty
                                <img
                                src={DefaultTrailer}
                                alt="Default"
                                style={{ width: "100px", marginTop: "10px" }}
                                />
                            )}
                        </FormGroup>
                        <FormGroup>
                            <Label>Trailer Name</Label>
                            <Input
                                type="text"
                                value={description}
                                placeholder="Name of the trailer"
                                onChange={(e) => setDescription(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Trailer Type</Label>
                            <Input
                                type="text"
                                value={type}
                                placeholder="Name of the trailer"
                                onChange={(e) => setType(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Trailer Max Height</Label>
                            <Input
                                type="text"
                                value={height}
                                placeholder="Trailer height"
                                onChange={(e) => setHeight(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Trailer Max Width</Label>
                            <Input
                                type="text"
                                value={width}
                                placeholder="Trailer width"
                                onChange={(e) => setWidth(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Trailer Max Length</Label>
                            <Input
                                type="text"
                                value={length}
                                placeholder="Trailer length"
                                onChange={(e) => setLength(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Trailer Max Capacity </Label>
                            <Input
                                type="text"
                                value={capacity}
                                placeholder="Trailer weight"
                                onChange={(e) => setCapacity(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Location </Label>
                            <Input
                                type="text"
                                value={location}
                                placeholder="Trailer type"
                                onChange={(e) => setLocation(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Base Price</Label>
                            <Input
                                type="text"
                                value={basePrice}
                                placeholder="Name of the trailer"
                                onChange={(e) => setBasePrice(e.target.value)}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Price Per Mile</Label>
                            <Input
                                type="text"
                                value={pricePerMile}
                                placeholder="Name of the trailer"
                                onChange={(e) => setPricePerMile(e.target.value)}
                            />
                        </FormGroup>
                        <ButtonToolbar className="gap-2">
                        <Button type="submit" color="success" style={{float: "right"}}>Save</Button>
                        {id && <Button color="danger" onClick={() => {navigate("/trailers")}}>Cancel</Button>}
                        </ButtonToolbar>
                    </Form>
                </CardBody>
            </Card>
        </PageContainer>
    )
}

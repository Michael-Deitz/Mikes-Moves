import { useNavigate, useParams } from "react-router-dom";
import { createItem, getItemsById, updateItem, } from "../../managers/itemManager";
import PageContainer from "../PageContainer";
import { Button, ButtonToolbar, Card, CardBody, Form, FormGroup, Input, Label } from "reactstrap";
import { useEffect, useState } from "react";
import DefaultItem from "../../resources/DefaultItem.png";

export default function CreateItem({ loggedInUser }) {
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [height, setHeight] = useState(0);
    const [width, setWidth] = useState(0);
    const [length, setLength] = useState(0);
    const [weight, setWeight] = useState(0);
    const [imageUrl, setImageUrl] = useState("");
    const [updatedItem, setUpdatedItem] = useState({});

    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        if (id) {
            getItemsById(id).then((item) => {
                setUpdatedItem(item);
                setName(item.name);
                setDescription(item.description);
                setHeight(item.height);
                setWidth(item.width);
                setLength(item.length);
                setWeight(item.weight);
                setImageUrl(item.imageUrl || DefaultItem);
            });
        }
    }, [id]);

    const handleSubmit = (e) => {
        e.preventDefault();

        const item = {
            name: name,
            description: description,
            height: height,
            width: width,
            length: length,
            weight: weight,
            imageUrl: imageUrl || DefaultItem,
            userProfileId: loggedInUser.id
        };

        if (id) {
            updateItem(updatedItem.id, item).then(() => navigate('/items'));
        } else {
            createItem(item).then(() => navigate("/items"));
        }
    }

    return (
        <PageContainer>
            {id ? (
                <h4 className="mt-2" style={{ display: 'flex', justifyContent: 'center' }}>Edit Your Item</h4>
            ) : (
                <h4 className="mt-2" style={{ display: 'flex', justifyContent: 'center' }}>Create A Item</h4>
            )}
            <Card className="w-75 shadow" outline color="light" style={{ maxWidth: "1200px" }}>
                <CardBody>
                    <Form className="w-50 m-auto"
                        style={{ maxWidth: "20rem" }}
                        onSubmit={handleSubmit}
                    >
                        <FormGroup>
                            <Label>Item Image</Label>
                            <Input
                                type="text"
                                value={imageUrl}
                                placeholder="Enter a image Url"
                                onChange={(e) => {
                                    setImageUrl(e.target.value);
                                }}
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
                                src={DefaultItem}
                                alt="Default"
                                style={{ width: "100px", marginTop: "10px" }}
                                />
                            )}
                        </FormGroup>
                        <FormGroup>
                            <Label>Item Name</Label>
                            <Input
                                type="text"
                                value={name}
                                placeholder="Name of item or items to be moved"
                                onChange={(e) => {
                                    setName(e.target.value);
                                }}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Item Height</Label>
                            <Input
                                type="text"
                                value={height}
                                placeholder="Item height"
                                onChange={(e) => {
                                    setHeight(e.target.value);
                                }}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Item Width</Label>
                            <Input
                                type="text"
                                value={width}
                                placeholder="Item width"
                                onChange={(e) => {
                                    setWidth(e.target.value);
                                }}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Item Length</Label>
                            <Input
                                type="text"
                                value={length}
                                placeholder="Item length"
                                onChange={(e) => {
                                    setLength(e.target.value);
                                }}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Item Weight</Label>
                            <Input
                                type="text"
                                value={weight}
                                placeholder="Item weight"
                                onChange={(e) => {
                                    setWeight(e.target.value);
                                }}
                            />
                        </FormGroup>
                        <FormGroup>
                            <Label>Item Description</Label>
                            <Input
                                type="text"
                                value={description}
                                placeholder="Description of item or items"
                                onChange={(e) => {
                                    setDescription(e.target.value);
                                }}
                            />
                        </FormGroup>
                        <ButtonToolbar className="gap-2">
                        <Button type="submit" color="success" style={{float: "right"}}>Save</Button>
                        {id && <Button color="danger" onClick={() => {navigate("/items")}}>Cancel</Button>}
                        </ButtonToolbar>
                    </Form>
                </CardBody>
            </Card>
        </PageContainer>
    )
}


import React from 'react';
import { Modal, ModalHeader, ModalBody, ListGroup, ListGroupItem, Button } from 'reactstrap';

export default function ReservedTrailersModal({ isOpen, toggle, reservedTrailers }) {
    return (
        <Modal isOpen={isOpen} toggle={toggle}>
            <ModalHeader toggle={toggle}>Reserved Trailers</ModalHeader>
            <ModalBody>
                <ListGroup>
                    {reservedTrailers.length > 0 ? (
                        reservedTrailers.map((trailer, index) => (
                            <ListGroupItem key={index}>
                                <strong>Description:</strong> {trailer.description} <br />
                                <strong>Reserved Date:</strong> {new Date(trailer.dateReserved).toLocaleDateString()}
                            </ListGroupItem>
                        ))
                    ) : (
                        <ListGroupItem>No reservations found.</ListGroupItem>
                    )}
                </ListGroup>
                <Button color="secondary" onClick={toggle} className="mt-3">Close</Button>
            </ModalBody>
        </Modal>
    );
}

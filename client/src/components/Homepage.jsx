import React from "react";
import { Container, Row, Col } from "reactstrap";
import './HomePage.css';

export default function HomePage() {
  return (
    <Container className="mt-5 homepage-container d-flex justify-content-center" style={{width: "50rem"}}>
      <Row className="align-items-center">
        <Col>
          <h1 className="display-1">Welcome to Mike's Moves</h1>
          <p className="lead">
            Your one-stop solution for all your moving needs. We offer a wide range of trailers to make your move smooth and hassle-free.
          </p>
          <p>
            Browse our collection of trailers, or create your own listings. Whether you are looking to rent or offer your equipment, Mike's Moves is here to help.
          </p>
          <p>
            We also allow our Users to post items they need to move. Allowing trailer owners to offer to move items,
          </p>
        </Col>
        {/* <Col md="6">
          <img src="welcome-image.jpg" alt="Welcome to Mike's Moves" className="img-fluid rounded" />
        </Col> */}
      </Row>
    </Container>
  );
}





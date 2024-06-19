import React from "react";
import { Container, Row, Col } from "reactstrap";
import './HomePage.css';

export default function HomePage() {
  return (
    <Container className="mt-5 homepage-container">
      <Row className="align-items-center">
        <Col md="6">
          <h1 className="display-3">Welcome to Mike's Moves</h1>
          <p className="lead">
            Your one-stop solution for all your moving needs. We offer a wide range of trailers and items to make your move smooth and hassle-free.
          </p>
          <p>
            Browse our collection of trailers and items, or create your own listings. Whether you are looking to rent or offer your equipment, Mike's Moves is here to help.
          </p>
        </Col>
        {/* <Col md="6">
          <img src="welcome-image.jpg" alt="Welcome to Mike's Moves" className="img-fluid rounded" />
        </Col> */}
      </Row>
    </Container>
  );
}





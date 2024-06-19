import React, { useState } from 'react';
import { Modal, ModalHeader, ModalBody, Dropdown, DropdownToggle, DropdownMenu, DropdownItem, Button } from 'reactstrap';

const FilterModal = () => {
  const [modalOpen, setModalOpen] = useState(false);
  const [dropdownOpen, setDropdownOpen] = useState(false);

  const toggleModal = () => {
    setModalOpen(!modalOpen);
  };

  const toggleDropdown = () => {
    setDropdownOpen(!dropdownOpen);
  };

  const navigateToUserPost = () => {
    // Navigate to the user's post page
  };

  return (
    <div>
      <Button color="primary" onClick={toggleModal}>Filters</Button>
      <Modal isOpen={modalOpen} toggle={toggleModal}>
        <ModalHeader toggle={toggleModal}>Filter Options</ModalHeader>
        <ModalBody className="d-flex justify-content-between">
          <Dropdown isOpen={dropdownOpen} toggle={toggleDropdown}>
            <DropdownToggle caret>
              Filter By
            </DropdownToggle>
            <DropdownMenu>
              <DropdownItem>Option 1</DropdownItem>
              <DropdownItem>Option 2</DropdownItem>
              <DropdownItem>Option 3</DropdownItem>
            </DropdownMenu>
          </Dropdown>
          <Button color="primary" onClick={navigateToUserPost}>View User's Post</Button>
        </ModalBody>
      </Modal>
    </div>
  );
};

export default FilterModal;

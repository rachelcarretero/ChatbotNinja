import { FormControl, FormGroup, Input, InputLabel, Input, Typography, Button, styled } from "@mui/material";

const container = styled(FormGroup)`
width;50%;
margin:5% auto;`

const label = { inputProps: { 'aria-label': 'Active' } };

const PersonalitiesAdd = () => {
    return (
        <FormGroup>
            <FormControl>
                <InputLabel>Name</InputLabel>
                <InputLabel>Description</InputLabel>
                <Checkbox {...label} defaultChecked />

            </FormControl>
        </FormGroup>

    );
} 
export default Footer;
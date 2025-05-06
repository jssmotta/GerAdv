"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import OponentesInc from "../Crud/Inc/Oponentes";
import { getParamFromUrl } from "@/app/tools/helpers";

interface OponentesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const OponentesIncContainer: React.FC<OponentesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/oponentes"); // 27012025
    const handleError = () => { };

    return (
        <OponentesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default OponentesIncContainer;
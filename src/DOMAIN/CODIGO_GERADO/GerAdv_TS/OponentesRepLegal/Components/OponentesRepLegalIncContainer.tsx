"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import OponentesRepLegalInc from "../Crud/Inc/OponentesRepLegal";
import { getParamFromUrl } from "@/app/tools/helpers";

interface OponentesRepLegalIncContainerProps {
    id: number;
    navigator: INavigator;
}

const OponentesRepLegalIncContainer: React.FC<OponentesRepLegalIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/oponentesreplegal"); // 27012025
    const handleError = () => { };

    return (
        <OponentesRepLegalInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default OponentesRepLegalIncContainer;
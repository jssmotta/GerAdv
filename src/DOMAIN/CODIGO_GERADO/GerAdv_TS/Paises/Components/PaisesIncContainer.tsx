"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import PaisesInc from "../Crud/Inc/Paises";
import { getParamFromUrl } from "@/app/tools/helpers";

interface PaisesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const PaisesIncContainer: React.FC<PaisesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/paises"); // 27012025
    const handleError = () => { };

    return (
        <PaisesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default PaisesIncContainer;
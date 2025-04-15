"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import OperadoresInc from "../Crud/Inc/Operadores";
import { getParamFromUrl } from "@/app/tools/helpers";

interface OperadoresIncContainerProps {
    id: number;
    navigator: INavigator;
}

const OperadoresIncContainer: React.FC<OperadoresIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/operadores"); // 27012025
    const handleError = () => { };

    return (
        <OperadoresInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default OperadoresIncContainer;
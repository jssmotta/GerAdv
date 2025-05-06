"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import OperadorInc from "../Crud/Inc/Operador";
import { getParamFromUrl } from "@/app/tools/helpers";

interface OperadorIncContainerProps {
    id: number;
    navigator: INavigator;
}

const OperadorIncContainer: React.FC<OperadorIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/operador"); // 27012025
    const handleError = () => { };

    return (
        <OperadorInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default OperadorIncContainer;
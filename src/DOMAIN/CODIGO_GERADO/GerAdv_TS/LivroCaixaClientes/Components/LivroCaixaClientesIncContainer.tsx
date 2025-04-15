"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import LivroCaixaClientesInc from "../Crud/Inc/LivroCaixaClientes";
import { getParamFromUrl } from "@/app/tools/helpers";

interface LivroCaixaClientesIncContainerProps {
    id: number;
    navigator: INavigator;
}

const LivroCaixaClientesIncContainer: React.FC<LivroCaixaClientesIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/livrocaixaclientes"); // 27012025
    const handleError = () => { };

    return (
        <LivroCaixaClientesInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default LivroCaixaClientesIncContainer;
"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ContratosInc from "../Crud/Inc/Contratos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ContratosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ContratosIncContainer: React.FC<ContratosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/contratos"); // 27012025
    const handleError = () => { };

    return (
        <ContratosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ContratosIncContainer;
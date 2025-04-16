"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import PontoVirtualAcessosInc from "../Crud/Inc/PontoVirtualAcessos";
import { getParamFromUrl } from "@/app/tools/helpers";

interface PontoVirtualAcessosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const PontoVirtualAcessosIncContainer: React.FC<PontoVirtualAcessosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/pontovirtualacessos"); // 27012025
    const handleError = () => { };

    return (
        <PontoVirtualAcessosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default PontoVirtualAcessosIncContainer;
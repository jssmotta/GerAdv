"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TipoValorProcessoInc from "../Crud/Inc/TipoValorProcesso";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TipoValorProcessoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TipoValorProcessoIncContainer: React.FC<TipoValorProcessoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/tipovalorprocesso"); // 27012025
    const handleError = () => { };

    return (
        <TipoValorProcessoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TipoValorProcessoIncContainer;
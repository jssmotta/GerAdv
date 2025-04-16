"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TipoStatusBiuInc from "../Crud/Inc/TipoStatusBiu";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TipoStatusBiuIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TipoStatusBiuIncContainer: React.FC<TipoStatusBiuIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/tipostatusbiu"); // 27012025
    const handleError = () => { };

    return (
        <TipoStatusBiuInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TipoStatusBiuIncContainer;
"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TipoCompromissoInc from "../Crud/Inc/TipoCompromisso";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TipoCompromissoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TipoCompromissoIncContainer: React.FC<TipoCompromissoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/tipocompromisso"); // 27012025
    const handleError = () => { };

    return (
        <TipoCompromissoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TipoCompromissoIncContainer;
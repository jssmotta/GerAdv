"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import GUTTipoInc from "../Crud/Inc/GUTTipo";
import { getParamFromUrl } from "@/app/tools/helpers";

interface GUTTipoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const GUTTipoIncContainer: React.FC<GUTTipoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/guttipo"); // 27012025
    const handleError = () => { };

    return (
        <GUTTipoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default GUTTipoIncContainer;
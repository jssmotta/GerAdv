"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import TiposAcaoInc from "../Crud/Inc/TiposAcao";
import { getParamFromUrl } from "@/app/tools/helpers";

interface TiposAcaoIncContainerProps {
    id: number;
    navigator: INavigator;
}

const TiposAcaoIncContainer: React.FC<TiposAcaoIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/tiposacao"); // 27012025
    const handleError = () => { };

    return (
        <TiposAcaoInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default TiposAcaoIncContainer;
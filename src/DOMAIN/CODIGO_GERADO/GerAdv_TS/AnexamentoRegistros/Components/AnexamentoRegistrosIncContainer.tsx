"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AnexamentoRegistrosInc from "../Crud/Inc/AnexamentoRegistros";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AnexamentoRegistrosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AnexamentoRegistrosIncContainer: React.FC<AnexamentoRegistrosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/anexamentoregistros"); // 27012025
    const handleError = () => { };

    return (
        <AnexamentoRegistrosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AnexamentoRegistrosIncContainer;
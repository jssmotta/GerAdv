"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import ProDespesasInc from "../Crud/Inc/ProDespesas";
import { getParamFromUrl } from "@/app/tools/helpers";

interface ProDespesasIncContainerProps {
    id: number;
    navigator: INavigator;
}

const ProDespesasIncContainer: React.FC<ProDespesasIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/prodespesas"); // 27012025
    const handleError = () => { };

    return (
        <ProDespesasInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default ProDespesasIncContainer;
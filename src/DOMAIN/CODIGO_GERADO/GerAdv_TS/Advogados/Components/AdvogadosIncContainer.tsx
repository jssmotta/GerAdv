"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AdvogadosInc from "../Crud/Inc/Advogados";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AdvogadosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AdvogadosIncContainer: React.FC<AdvogadosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/advogados"); // 27012025
    const handleError = () => { };

    return (
        <AdvogadosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AdvogadosIncContainer;
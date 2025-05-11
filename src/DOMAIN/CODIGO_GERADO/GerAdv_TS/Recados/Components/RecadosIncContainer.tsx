"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import RecadosInc from "../Crud/Inc/Recados";
import { getParamFromUrl } from "@/app/tools/helpers";

interface RecadosIncContainerProps {
    id: number;
    navigator: INavigator;
}

const RecadosIncContainer: React.FC<RecadosIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/recados"); // 27012025
    const handleError = () => { };

    return (
        <RecadosInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default RecadosIncContainer;
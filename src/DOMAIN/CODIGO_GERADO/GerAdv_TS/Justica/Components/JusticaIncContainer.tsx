"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import JusticaInc from "../Crud/Inc/Justica";
import { getParamFromUrl } from "@/app/tools/helpers";

interface JusticaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const JusticaIncContainer: React.FC<JusticaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/justica"); // 27012025
    const handleError = () => { };

    return (
        <JusticaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default JusticaIncContainer;
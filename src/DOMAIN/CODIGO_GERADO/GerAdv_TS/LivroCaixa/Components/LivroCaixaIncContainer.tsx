"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import LivroCaixaInc from "../Crud/Inc/LivroCaixa";
import { getParamFromUrl } from "@/app/tools/helpers";

interface LivroCaixaIncContainerProps {
    id: number;
    navigator: INavigator;
}

const LivroCaixaIncContainer: React.FC<LivroCaixaIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/livrocaixa"); // 27012025
    const handleError = () => { };

    return (
        <LivroCaixaInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default LivroCaixaIncContainer;
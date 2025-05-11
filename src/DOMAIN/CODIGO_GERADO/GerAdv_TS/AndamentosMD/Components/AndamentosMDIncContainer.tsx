"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AndamentosMDInc from "../Crud/Inc/AndamentosMD";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AndamentosMDIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AndamentosMDIncContainer: React.FC<AndamentosMDIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/andamentosmd"); // 27012025
    const handleError = () => { };

    return (
        <AndamentosMDInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AndamentosMDIncContainer;
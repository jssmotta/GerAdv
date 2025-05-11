"use client";
import { INavigator } from "@/app/interfaces/INavigator";
import AgendaFinanceiroInc from "../Crud/Inc/AgendaFinanceiro";
import { getParamFromUrl } from "@/app/tools/helpers";

interface AgendaFinanceiroIncContainerProps {
    id: number;
    navigator: INavigator;
}

const AgendaFinanceiroIncContainer: React.FC<AgendaFinanceiroIncContainerProps> = ({ id, navigator }) => {
    const handleClose = () => navigator.navigateTo("/dashboard");
    const handleSuccess = () => navigator.navigateTo("/pages/agendafinanceiro"); // 27012025
    const handleError = () => { };

    return (
        <AgendaFinanceiroInc 
            id={id}
            onClose={handleClose}
            onSuccess={handleSuccess}
            onError={handleError}
        />
    );
};

export default AgendaFinanceiroIncContainer;
import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import AgendaFinanceiroInc from "../Inc/AgendaFinanceiro";
import { IAgendaFinanceiro } from "../../Interfaces/interface.AgendaFinanceiro";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AgendaFinanceiroEmpty } from "@/app/GerAdv_TS/Models/AgendaFinanceiro";
import { useWindow } from "@/app/hooks/useWindows";

interface AgendaFinanceiroWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgendaFinanceiro?: IAgendaFinanceiro;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaFinanceiroWindow: React.FC<AgendaFinanceiroWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgendaFinanceiro,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agendafinanceiro/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgendaFinanceiro?.id}`);
        }

    }, [isMobile, router, selectedAgendaFinanceiro]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedAgendaFinanceiro?.id ?? 0).toString()}
                >
                    <AgendaFinanceiroInc
                        id={selectedAgendaFinanceiro?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgendaFinanceiro: React.FC<AgendaFinanceiroWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AgendaFinanceiroWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgendaFinanceiro={AgendaFinanceiroEmpty()}>
        </AgendaFinanceiroWindow>
    )
};

export default AgendaFinanceiroWindow;
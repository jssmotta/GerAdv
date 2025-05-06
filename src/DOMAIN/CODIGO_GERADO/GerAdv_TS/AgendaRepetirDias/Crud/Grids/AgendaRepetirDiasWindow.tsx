import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AgendaRepetirDiasInc from "../Inc/AgendaRepetirDias";
import { IAgendaRepetirDias } from "../../Interfaces/interface.AgendaRepetirDias";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AgendaRepetirDiasEmpty } from "@/app/GerAdv_TS/Models/AgendaRepetirDias";
import { useWindow } from "@/app/hooks/useWindows";

interface AgendaRepetirDiasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgendaRepetirDias?: IAgendaRepetirDias;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaRepetirDiasWindow: React.FC<AgendaRepetirDiasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgendaRepetirDias,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agendarepetirdias/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgendaRepetirDias?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAgendaRepetirDias]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAgendaRepetirDias?.id ?? 0).toString()}
                >
                    <AgendaRepetirDiasInc
                        id={selectedAgendaRepetirDias?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgendaRepetirDias: React.FC<AgendaRepetirDiasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AgendaRepetirDiasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgendaRepetirDias={AgendaRepetirDiasEmpty()}>
        </AgendaRepetirDiasWindow>
    )
};

export default AgendaRepetirDiasWindow;
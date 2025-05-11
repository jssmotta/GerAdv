import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AgendaInc from "../Inc/Agenda";
import { IAgenda } from "../../Interfaces/interface.Agenda";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AgendaEmpty } from "@/app/GerAdv_TS/Models/Agenda";
import { useWindow } from "@/app/hooks/useWindows";

interface AgendaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgenda?: IAgenda;
    onSuccess: () => void;
    onError: () => void;
}

const AgendaWindow: React.FC<AgendaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgenda,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgenda?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAgenda]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedAgenda?.id ?? 0).toString()}
                >
                    <AgendaInc
                        id={selectedAgenda?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgenda: React.FC<AgendaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AgendaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgenda={AgendaEmpty()}>
        </AgendaWindow>
    )
};

export default AgendaWindow;
import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import Agenda2AgendaInc from "../Inc/Agenda2Agenda";
import { IAgenda2Agenda } from "../../Interfaces/interface.Agenda2Agenda";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { Agenda2AgendaEmpty } from "@/app/GerAdv_TS/Models/Agenda2Agenda";
import { useWindow } from "@/app/hooks/useWindows";

interface Agenda2AgendaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAgenda2Agenda?: IAgenda2Agenda;
    onSuccess: () => void;
    onError: () => void;
}

const Agenda2AgendaWindow: React.FC<Agenda2AgendaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAgenda2Agenda,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/agenda2agenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAgenda2Agenda?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAgenda2Agenda]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAgenda2Agenda?.id ?? 0).toString()}
                >
                    <Agenda2AgendaInc
                        id={selectedAgenda2Agenda?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAgenda2Agenda: React.FC<Agenda2AgendaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <Agenda2AgendaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAgenda2Agenda={Agenda2AgendaEmpty()}>
        </Agenda2AgendaWindow>
    )
};

export default Agenda2AgendaWindow;
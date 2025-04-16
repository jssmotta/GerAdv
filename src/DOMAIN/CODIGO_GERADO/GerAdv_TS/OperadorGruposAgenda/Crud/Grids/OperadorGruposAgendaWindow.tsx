import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import OperadorGruposAgendaInc from "../Inc/OperadorGruposAgenda";
import { IOperadorGruposAgenda } from "../../Interfaces/interface.OperadorGruposAgenda";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OperadorGruposAgendaEmpty } from "@/app/GerAdv_TS/Models/OperadorGruposAgenda";
import { useWindow } from "@/app/hooks/useWindows";

interface OperadorGruposAgendaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOperadorGruposAgenda?: IOperadorGruposAgenda;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorGruposAgendaWindow: React.FC<OperadorGruposAgendaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOperadorGruposAgenda,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/operadorgruposagenda/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOperadorGruposAgenda?.id}`);
        }

    }, [isMobile, router, selectedOperadorGruposAgenda]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedOperadorGruposAgenda?.id ?? 0).toString()}
                >
                    <OperadorGruposAgendaInc
                        id={selectedOperadorGruposAgenda?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOperadorGruposAgenda: React.FC<OperadorGruposAgendaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OperadorGruposAgendaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOperadorGruposAgenda={OperadorGruposAgendaEmpty()}>
        </OperadorGruposAgendaWindow>
    )
};

export default OperadorGruposAgendaWindow;
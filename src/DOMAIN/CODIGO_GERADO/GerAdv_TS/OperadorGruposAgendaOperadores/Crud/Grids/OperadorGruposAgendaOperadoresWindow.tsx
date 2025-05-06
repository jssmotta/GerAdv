import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import OperadorGruposAgendaOperadoresInc from "../Inc/OperadorGruposAgendaOperadores";
import { IOperadorGruposAgendaOperadores } from "../../Interfaces/interface.OperadorGruposAgendaOperadores";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OperadorGruposAgendaOperadoresEmpty } from "@/app/GerAdv_TS/Models/OperadorGruposAgendaOperadores";
import { useWindow } from "@/app/hooks/useWindows";

interface OperadorGruposAgendaOperadoresWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOperadorGruposAgendaOperadores?: IOperadorGruposAgendaOperadores;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorGruposAgendaOperadoresWindow: React.FC<OperadorGruposAgendaOperadoresWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOperadorGruposAgendaOperadores,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/operadorgruposagendaoperadores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOperadorGruposAgendaOperadores?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedOperadorGruposAgendaOperadores]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedOperadorGruposAgendaOperadores?.id ?? 0).toString()}
                >
                    <OperadorGruposAgendaOperadoresInc
                        id={selectedOperadorGruposAgendaOperadores?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOperadorGruposAgendaOperadores: React.FC<OperadorGruposAgendaOperadoresWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OperadorGruposAgendaOperadoresWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOperadorGruposAgendaOperadores={OperadorGruposAgendaOperadoresEmpty()}>
        </OperadorGruposAgendaOperadoresWindow>
    )
};

export default OperadorGruposAgendaOperadoresWindow;
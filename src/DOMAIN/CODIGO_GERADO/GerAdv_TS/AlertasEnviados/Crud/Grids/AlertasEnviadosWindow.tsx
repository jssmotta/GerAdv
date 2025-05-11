import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import AlertasEnviadosInc from "../Inc/AlertasEnviados";
import { IAlertasEnviados } from "../../Interfaces/interface.AlertasEnviados";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AlertasEnviadosEmpty } from "@/app/GerAdv_TS/Models/AlertasEnviados";
import { useWindow } from "@/app/hooks/useWindows";

interface AlertasEnviadosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAlertasEnviados?: IAlertasEnviados;
    onSuccess: () => void;
    onError: () => void;
}

const AlertasEnviadosWindow: React.FC<AlertasEnviadosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAlertasEnviados,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/alertasenviados/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAlertasEnviados?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedAlertasEnviados]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAlertasEnviados?.id ?? 0).toString()}
                >
                    <AlertasEnviadosInc
                        id={selectedAlertasEnviados?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAlertasEnviados: React.FC<AlertasEnviadosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AlertasEnviadosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAlertasEnviados={AlertasEnviadosEmpty()}>
        </AlertasEnviadosWindow>
    )
};

export default AlertasEnviadosWindow;
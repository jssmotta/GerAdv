import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import AlertasInc from "../Inc/Alertas";
import { IAlertas } from "../../Interfaces/interface.Alertas";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AlertasEmpty } from "@/app/GerAdv_TS/Models/Alertas";
import { useWindow } from "@/app/hooks/useWindows";

interface AlertasWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAlertas?: IAlertas;
    onSuccess: () => void;
    onError: () => void;
}

const AlertasWindow: React.FC<AlertasWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAlertas,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/alertas/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAlertas?.id}`);
        }

    }, [isMobile, router, selectedAlertas]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAlertas?.id ?? 0).toString()}
                >
                    <AlertasInc
                        id={selectedAlertas?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAlertas: React.FC<AlertasWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AlertasWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAlertas={AlertasEmpty()}>
        </AlertasWindow>
    )
};

export default AlertasWindow;
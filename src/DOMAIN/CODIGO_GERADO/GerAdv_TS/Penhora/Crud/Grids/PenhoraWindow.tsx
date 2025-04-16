import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import PenhoraInc from "../Inc/Penhora";
import { IPenhora } from "../../Interfaces/interface.Penhora";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PenhoraEmpty } from "@/app/GerAdv_TS/Models/Penhora";
import { useWindow } from "@/app/hooks/useWindows";

interface PenhoraWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPenhora?: IPenhora;
    onSuccess: () => void;
    onError: () => void;
}

const PenhoraWindow: React.FC<PenhoraWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPenhora,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/penhora/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPenhora?.id}`);
        }

    }, [isMobile, router, selectedPenhora]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={633}
                    newWidth={720}
                    id={(selectedPenhora?.id ?? 0).toString()}
                >
                    <PenhoraInc
                        id={selectedPenhora?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPenhora: React.FC<PenhoraWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PenhoraWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPenhora={PenhoraEmpty()}>
        </PenhoraWindow>
    )
};

export default PenhoraWindow;
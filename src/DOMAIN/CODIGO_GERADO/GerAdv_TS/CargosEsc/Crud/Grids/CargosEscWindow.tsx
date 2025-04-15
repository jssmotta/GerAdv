import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import CargosEscInc from "../Inc/CargosEsc";
import { ICargosEsc } from "../../Interfaces/interface.CargosEsc";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { CargosEscEmpty } from "@/app/GerAdv_TS/Models/CargosEsc";
import { useWindow } from "@/app/hooks/useWindows";

interface CargosEscWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedCargosEsc?: ICargosEsc;
    onSuccess: () => void;
    onError: () => void;
}

const CargosEscWindow: React.FC<CargosEscWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedCargosEsc,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/cargosesc/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedCargosEsc?.id}`);
        }

    }, [isMobile, router, selectedCargosEsc]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedCargosEsc?.id ?? 0).toString()}
                >
                    <CargosEscInc
                        id={selectedCargosEsc?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowCargosEsc: React.FC<CargosEscWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <CargosEscWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedCargosEsc={CargosEscEmpty()}>
        </CargosEscWindow>
    )
};

export default CargosEscWindow;
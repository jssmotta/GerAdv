import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import CargosEscClassInc from "../Inc/CargosEscClass";
import { ICargosEscClass } from "../../Interfaces/interface.CargosEscClass";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { CargosEscClassEmpty } from "@/app/GerAdv_TS/Models/CargosEscClass";
import { useWindow } from "@/app/hooks/useWindows";

interface CargosEscClassWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedCargosEscClass?: ICargosEscClass;
    onSuccess: () => void;
    onError: () => void;
}

const CargosEscClassWindow: React.FC<CargosEscClassWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedCargosEscClass,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/cargosescclass/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedCargosEscClass?.id}`);
        }

    }, [isMobile, router, selectedCargosEscClass]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedCargosEscClass?.id ?? 0).toString()}
                >
                    <CargosEscClassInc
                        id={selectedCargosEscClass?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowCargosEscClass: React.FC<CargosEscClassWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <CargosEscClassWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedCargosEscClass={CargosEscClassEmpty()}>
        </CargosEscClassWindow>
    )
};

export default CargosEscClassWindow;
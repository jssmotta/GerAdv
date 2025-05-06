import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import PaisesInc from "../Inc/Paises";
import { IPaises } from "../../Interfaces/interface.Paises";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PaisesEmpty } from "@/app/GerAdv_TS/Models/Paises";
import { useWindow } from "@/app/hooks/useWindows";

interface PaisesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPaises?: IPaises;
    onSuccess: () => void;
    onError: () => void;
}

const PaisesWindow: React.FC<PaisesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPaises,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/paises/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPaises?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedPaises]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedPaises?.id ?? 0).toString()}
                >
                    <PaisesInc
                        id={selectedPaises?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPaises: React.FC<PaisesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PaisesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPaises={PaisesEmpty()}>
        </PaisesWindow>
    )
};

export default PaisesWindow;
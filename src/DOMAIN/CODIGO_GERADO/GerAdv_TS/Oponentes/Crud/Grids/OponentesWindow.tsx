import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import OponentesInc from "../Inc/Oponentes";
import { IOponentes } from "../../Interfaces/interface.Oponentes";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OponentesEmpty } from "@/app/GerAdv_TS/Models/Oponentes";
import { useWindow } from "@/app/hooks/useWindows";

interface OponentesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOponentes?: IOponentes;
    onSuccess: () => void;
    onError: () => void;
}

const OponentesWindow: React.FC<OponentesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOponentes,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/oponentes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOponentes?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedOponentes]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedOponentes?.id ?? 0).toString()}
                >
                    <OponentesInc
                        id={selectedOponentes?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOponentes: React.FC<OponentesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OponentesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOponentes={OponentesEmpty()}>
        </OponentesWindow>
    )
};

export default OponentesWindow;
import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import OponentesRepLegalInc from "../Inc/OponentesRepLegal";
import { IOponentesRepLegal } from "../../Interfaces/interface.OponentesRepLegal";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OponentesRepLegalEmpty } from "@/app/GerAdv_TS/Models/OponentesRepLegal";
import { useWindow } from "@/app/hooks/useWindows";

interface OponentesRepLegalWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOponentesRepLegal?: IOponentesRepLegal;
    onSuccess: () => void;
    onError: () => void;
}

const OponentesRepLegalWindow: React.FC<OponentesRepLegalWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOponentesRepLegal,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/oponentesreplegal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOponentesRepLegal?.id}`);
        }

    }, [isMobile, router, selectedOponentesRepLegal]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={641}
                    newWidth={1440}
                    id={(selectedOponentesRepLegal?.id ?? 0).toString()}
                >
                    <OponentesRepLegalInc
                        id={selectedOponentesRepLegal?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOponentesRepLegal: React.FC<OponentesRepLegalWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OponentesRepLegalWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOponentesRepLegal={OponentesRepLegalEmpty()}>
        </OponentesRepLegalWindow>
    )
};

export default OponentesRepLegalWindow;
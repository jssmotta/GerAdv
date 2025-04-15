import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import OperadorEMailPopupInc from "../Inc/OperadorEMailPopup";
import { IOperadorEMailPopup } from "../../Interfaces/interface.OperadorEMailPopup";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { OperadorEMailPopupEmpty } from "@/app/GerAdv_TS/Models/OperadorEMailPopup";
import { useWindow } from "@/app/hooks/useWindows";

interface OperadorEMailPopupWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedOperadorEMailPopup?: IOperadorEMailPopup;
    onSuccess: () => void;
    onError: () => void;
}

const OperadorEMailPopupWindow: React.FC<OperadorEMailPopupWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedOperadorEMailPopup,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/operadoremailpopup/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedOperadorEMailPopup?.id}`);
        }

    }, [isMobile, router, selectedOperadorEMailPopup]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={596}
                    newWidth={1440}
                    id={(selectedOperadorEMailPopup?.id ?? 0).toString()}
                >
                    <OperadorEMailPopupInc
                        id={selectedOperadorEMailPopup?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowOperadorEMailPopup: React.FC<OperadorEMailPopupWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <OperadorEMailPopupWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedOperadorEMailPopup={OperadorEMailPopupEmpty()}>
        </OperadorEMailPopupWindow>
    )
};

export default OperadorEMailPopupWindow;
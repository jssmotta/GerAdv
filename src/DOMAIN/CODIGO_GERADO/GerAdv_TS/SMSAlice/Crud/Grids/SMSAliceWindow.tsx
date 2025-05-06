import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import SMSAliceInc from "../Inc/SMSAlice";
import { ISMSAlice } from "../../Interfaces/interface.SMSAlice";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { SMSAliceEmpty } from "@/app/GerAdv_TS/Models/SMSAlice";
import { useWindow } from "@/app/hooks/useWindows";

interface SMSAliceWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedSMSAlice?: ISMSAlice;
    onSuccess: () => void;
    onError: () => void;
}

const SMSAliceWindow: React.FC<SMSAliceWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedSMSAlice,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/smsalice/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedSMSAlice?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedSMSAlice]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedSMSAlice?.id ?? 0).toString()}
                >
                    <SMSAliceInc
                        id={selectedSMSAlice?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowSMSAlice: React.FC<SMSAliceWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <SMSAliceWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedSMSAlice={SMSAliceEmpty()}>
        </SMSAliceWindow>
    )
};

export default SMSAliceWindow;
import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import AlarmSMSInc from "../Inc/AlarmSMS";
import { IAlarmSMS } from "../../Interfaces/interface.AlarmSMS";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AlarmSMSEmpty } from "@/app/GerAdv_TS/Models/AlarmSMS";
import { useWindow } from "@/app/hooks/useWindows";

interface AlarmSMSWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAlarmSMS?: IAlarmSMS;
    onSuccess: () => void;
    onError: () => void;
}

const AlarmSMSWindow: React.FC<AlarmSMSWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAlarmSMS,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/alarmsms/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAlarmSMS?.id}`);
        }

    }, [isMobile, router, selectedAlarmSMS]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={627}
                    newWidth={1440}
                    id={(selectedAlarmSMS?.id ?? 0).toString()}
                >
                    <AlarmSMSInc
                        id={selectedAlarmSMS?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAlarmSMS: React.FC<AlarmSMSWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AlarmSMSWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAlarmSMS={AlarmSMSEmpty()}>
        </AlarmSMSWindow>
    )
};

export default AlarmSMSWindow;
import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ReuniaoInc from "../Inc/Reuniao";
import { IReuniao } from "../../Interfaces/interface.Reuniao";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ReuniaoEmpty } from "@/app/GerAdv_TS/Models/Reuniao";
import { useWindow } from "@/app/hooks/useWindows";

interface ReuniaoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedReuniao?: IReuniao;
    onSuccess: () => void;
    onError: () => void;
}

const ReuniaoWindow: React.FC<ReuniaoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedReuniao,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/reuniao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedReuniao?.id}`);
        }

    }, [isMobile, router, selectedReuniao]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={596}
                    newWidth={1440}
                    id={(selectedReuniao?.id ?? 0).toString()}
                >
                    <ReuniaoInc
                        id={selectedReuniao?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowReuniao: React.FC<ReuniaoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ReuniaoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedReuniao={ReuniaoEmpty()}>
        </ReuniaoWindow>
    )
};

export default ReuniaoWindow;
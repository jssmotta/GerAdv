import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ProDepositosInc from "../Inc/ProDepositos";
import { IProDepositos } from "../../Interfaces/interface.ProDepositos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProDepositosEmpty } from "@/app/GerAdv_TS/Models/ProDepositos";
import { useWindow } from "@/app/hooks/useWindows";

interface ProDepositosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProDepositos?: IProDepositos;
    onSuccess: () => void;
    onError: () => void;
}

const ProDepositosWindow: React.FC<ProDepositosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProDepositos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/prodepositos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProDepositos?.id}`);
        }

    }, [isMobile, router, selectedProDepositos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={633}
                    newWidth={720}
                    id={(selectedProDepositos?.id ?? 0).toString()}
                >
                    <ProDepositosInc
                        id={selectedProDepositos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProDepositos: React.FC<ProDepositosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProDepositosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProDepositos={ProDepositosEmpty()}>
        </ProDepositosWindow>
    )
};

export default ProDepositosWindow;
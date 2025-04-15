import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import RamalInc from "../Inc/Ramal";
import { IRamal } from "../../Interfaces/interface.Ramal";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { RamalEmpty } from "@/app/GerAdv_TS/Models/Ramal";
import { useWindow } from "@/app/hooks/useWindows";

interface RamalWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedRamal?: IRamal;
    onSuccess: () => void;
    onError: () => void;
}

const RamalWindow: React.FC<RamalWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedRamal,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/ramal/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedRamal?.id}`);
        }

    }, [isMobile, router, selectedRamal]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedRamal?.id ?? 0).toString()}
                >
                    <RamalInc
                        id={selectedRamal?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowRamal: React.FC<RamalWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <RamalWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedRamal={RamalEmpty()}>
        </RamalWindow>
    )
};

export default RamalWindow;
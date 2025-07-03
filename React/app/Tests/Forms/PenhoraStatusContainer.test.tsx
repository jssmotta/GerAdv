import React from 'react';
import { render } from '@testing-library/react';
import PenhoraStatusIncContainer from '@/app/GerAdv_TS/PenhoraStatus/Components/PenhoraStatusIncContainer';
// PenhoraStatusIncContainer.test.tsx
// Mock do PenhoraStatusInc
jest.mock('@/app/GerAdv_TS/PenhoraStatus/Crud/Inc/PenhoraStatus', () => (props: any) => (
<div data-testid='penhorastatus-inc-mock' {...props} />
));
describe('PenhoraStatusIncContainer', () => {
  it('deve renderizar PenhoraStatusInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <PenhoraStatusIncContainer id={id} navigator={mockNavigator} />
  );
  const penhorastatusInc = getByTestId('penhorastatus-inc-mock');
  expect(penhorastatusInc).toBeInTheDocument();
  expect(penhorastatusInc.getAttribute('id')).toBe(id.toString());

});
});
import React from 'react';
import { render } from '@testing-library/react';
import PenhoraIncContainer from '@/app/GerAdv_TS/Penhora/Components/PenhoraIncContainer';
// PenhoraIncContainer.test.tsx
// Mock do PenhoraInc
jest.mock('@/app/GerAdv_TS/Penhora/Crud/Inc/Penhora', () => (props: any) => (
<div data-testid='penhora-inc-mock' {...props} />
));
describe('PenhoraIncContainer', () => {
  it('deve renderizar PenhoraInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <PenhoraIncContainer id={id} navigator={mockNavigator} />
  );
  const penhoraInc = getByTestId('penhora-inc-mock');
  expect(penhoraInc).toBeInTheDocument();
  expect(penhoraInc.getAttribute('id')).toBe(id.toString());

});
});
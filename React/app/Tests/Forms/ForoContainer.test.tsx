import React from 'react';
import { render } from '@testing-library/react';
import ForoIncContainer from '@/app/GerAdv_TS/Foro/Components/ForoIncContainer';
// ForoIncContainer.test.tsx
// Mock do ForoInc
jest.mock('@/app/GerAdv_TS/Foro/Crud/Inc/Foro', () => (props: any) => (
<div data-testid='foro-inc-mock' {...props} />
));
describe('ForoIncContainer', () => {
  it('deve renderizar ForoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <ForoIncContainer id={id} navigator={mockNavigator} />
  );
  const foroInc = getByTestId('foro-inc-mock');
  expect(foroInc).toBeInTheDocument();
  expect(foroInc.getAttribute('id')).toBe(id.toString());

});
});